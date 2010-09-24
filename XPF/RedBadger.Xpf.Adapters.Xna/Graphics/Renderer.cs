﻿namespace RedBadger.Xpf.Adapters.Xna.Graphics
{
    using System.Collections.Generic;
    using System.Linq;

    using RedBadger.Xpf.Graphics;

    public class Renderer : IRenderer
    {
        private readonly LinkedList<DrawingContext> drawList = new LinkedList<DrawingContext>();

        private readonly Dictionary<IElement, LinkedListNode<DrawingContext>> drawingContexts =
            new Dictionary<IElement, LinkedListNode<DrawingContext>>();

        private readonly IPrimitivesService primitivesService;

        private readonly ISpriteBatch spriteBatch;

        private bool isPreDrawRequired;

        public Renderer(ISpriteBatch spriteBatch, IPrimitivesService primitivesService)
        {
            this.spriteBatch = spriteBatch;
            this.primitivesService = primitivesService;
        }

        public void ClearInvalidDrawingContexts()
        {
            this.ClearContextsWithOrphanedElements();

            foreach (var drawingContext in this.drawingContexts.Values)
            {
                drawingContext.Value.ClearIfInvalid();
            }
        }

        public void Draw()
        {
            foreach (DrawingContext linkedContext in this.drawList)
            {
                linkedContext.Draw(this.spriteBatch);
            }

            this.spriteBatch.End();
        }

        public IDrawingContext GetDrawingContext(IElement element)
        {
            LinkedListNode<DrawingContext> node;

            if (this.drawingContexts.TryGetValue(element, out node))
            {
                node.Value.Clear();
            }
            else
            {
                node = new LinkedListNode<DrawingContext>(new DrawingContext(element, this.primitivesService));
                this.drawingContexts.Add(element, node);
            }

            this.isPreDrawRequired = true;
            return node.Value;
        }

        public void PreDraw(IElement rootElement)
        {
            if (this.isPreDrawRequired)
            {
                this.drawList.Clear();
                this.PreDraw(rootElement, rootElement.VisualOffset, Rect.Empty);

                this.isPreDrawRequired = false;
            }
        }

        private void ClearContextsWithOrphanedElements()
        {
            this.drawingContexts.Keys.Where(element => element.VisualParent == null).ToList().ForEach(
                orphan => this.drawingContexts.Remove(orphan));
        }

        private void PreDraw(
            IElement element, Vector absoluteOffset, Rect absoluteClippingRect)
        {
            LinkedListNode<DrawingContext> node;
            if (this.drawingContexts.TryGetValue(element, out node))
            {
                DrawingContext drawingContext = node.Value;

                absoluteOffset += element.VisualOffset;
                drawingContext.AbsoluteOffset = absoluteOffset;

                if (!drawingContext.ClippingRect.IsEmpty)
                {
                    Rect clippingRect = drawingContext.ClippingRect;
                    clippingRect.Displace(absoluteOffset);

                    clippingRect.Intersect(absoluteClippingRect);
                    if (clippingRect.IsEmpty)
                    {
                        clippingRect = absoluteClippingRect;
                    }

                    drawingContext.AbsoluteClippingRect = clippingRect;
                    this.drawList.AddLast(node);
                }

                foreach (IElement child in element.GetVisualChildren())
                {
                    this.PreDraw(child, absoluteOffset, drawingContext.AbsoluteClippingRect);
                }
            }
        }
    }
}