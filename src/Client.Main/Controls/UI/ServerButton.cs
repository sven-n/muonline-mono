using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Net.NetworkInformation;

namespace Client.Main.Controls.UI
{
    public class ServerButton : SpriteControl
    {
        private readonly LabelControl _label;
        private SpriteControl _status;

        public byte Gauge { get; set; } = 0;
        public bool Available => Gauge < 100f;

        public byte Index { get; set; }
        public string Name { get => _label.Text; set => _label.Text = value; }

        public ServerButton()
        {
            Height = 26;
            Width = 192;

            Interactive = true;
            TileWidth = 192;
            TileHeight = 26;
            TileY = 0;
            BlendState = BlendState.AlphaBlend;
            TexturePath = "Interface/server_b2_all.tga";

            Controls.Add(_label = new LabelControl
            {
                Align = Align.Center,
                Width = 192,
                Y = 4
            });

            Controls.Add(_status = new SpriteControl
            {
                TexturePath = "Interface/server_b2_loding.jpg",
                X = 9,
                Y = 19,
                TileWidth = 18,
                TileHeight = 4,
            });
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Interactive = Available;
            _status.TileWidth = 167 * Gauge / 100;

            if (!Available)
                TileY = 2;
            else if (MuGame.Instance.ActiveScene.MouseControl == this)
                TileY = 1;
            else
                TileY = 0;
        }
    }
}