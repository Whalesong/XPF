using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using RedBadger.Xpf.Data;
using RedBadger.Xpf.Media;
using RedBadger.Xpf.Media.Imaging;

using RxBool = System.Reactive.MonoTouch.ValueWrapper<bool>;
namespace Xpf.Mono.Samples.iOS.Samples.XpfSamples.S05.WithoutBindingFactory
{
    public class Card
    {
        private readonly TextureImage faceDownImage;

        private readonly TextureImage faceUpImage;

        private readonly ISubject<ImageSource> cardImage = new Subject<ImageSource>();

        private readonly ISubject<RxBool> isCardFaceUp = new Subject<RxBool>();

        public Card(TextureImage faceDownImage, TextureImage faceUpImage)
        {
            this.faceDownImage = faceDownImage;
            this.faceUpImage = faceUpImage;

            this.isCardFaceUp.Subscribe(this.OnIsCardFaceUpChanged);

            this.cardImage.OnNext(this.faceDownImage);
            this.isCardFaceUp.OnNext(false);
        }

        public IObservable<ImageSource> CardImage
        {
            get
            {
                return this.cardImage.AsObservable();
            }
        }

        public ISubject<RxBool> IsCardFaceUp
        {
            get
            {
                return this.isCardFaceUp;
            }
        }

        public void Reset()
        {
            this.isCardFaceUp.OnNext(false);
        }

        private void OnIsCardFaceUpChanged(RxBool value)
        {
            //if (value.HasValue)
            //{
            this.cardImage.OnNext((bool)value ? this.faceUpImage : this.faceDownImage);
            //}
        }
    }
}
