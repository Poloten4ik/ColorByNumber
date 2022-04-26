using FancyCarouselView.Runtime.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.Scripts
{
    public class DemoCarouselCell : CarouselCell<DemoData, DemoCarouselCell>
    {
        [SerializeField] private Image _image = default;
        [SerializeField] private string _urlJigsaw;
        [SerializeField] private string _url;

        protected override void Refresh(DemoData data)
        {
            _image.sprite = Resources.Load<Sprite>(data.SpriteResourceKey);
        }

        public void BannerClick()
        {
            if (_image.sprite.name == "tex_demo_banner_00" || _image.sprite.name == "tex_demo_banner_03")
            {
                Application.OpenURL(_urlJigsaw);
            }
            else
            {
                Application.OpenURL(_url);
            }
            
        }
    }
}