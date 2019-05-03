using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace monogame_bitmapfont
{
    internal class glyph
    {
        public Rectangle rect;
        public Vector2 pos;
        public int size;

        public glyph(Rectangle rect, Vector2 pos, int size)
        {
            this.rect = rect;
            this.pos = pos;
            this.size = size;
        }
    }

    public class BitmapFont
    {
        private int rowCount = 0;
        private int itemCount = 0;
        private int itemSize = 0;
        List<glyph> _glyphs = new List<glyph>();
        private Texture2D bitmapTex2D;

        /*public BitmapFont(SpriteBatch batch, GraphicsDevice graphicsDevice)
        {
            //this.batch = batch;
            this.graphicsDevice = graphicsDevice;
        }*/

        public void LoadContent(ContentManager ctx)
        {
            bitmapTex2D = ctx.Load<Texture2D>("fonts/conchars");
        }

        public void LoadContent(ContentManager ctx, string fontName)
        {
            bitmapTex2D = ctx.Load<Texture2D>(fontName);
        }

        public void setText(string text, int fontSize, Vector2 pos, Color color, SpriteBatch batch)
        {
            int tabSize = 16;
            int tableLenght = 15; //16
            int tableHeight = 15; //16
            string filter = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~ ";

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < filter.Length; j++)
                {
                    if (filter[j].Equals(text[i]))
                    {
                        Console.WriteLine("filter: {0} - text: {1} it:{4} - X:{2} - Y:{3}", filter[j], text[i], 16 * itemCount, 16 * rowCount, j);
                        _glyphs.Add(new glyph(new Rectangle(16 * itemCount, 16 * rowCount, 16, 16), new Vector2(pos.X + (fontSize * i), pos.Y), fontSize));
                        itemCount = 0;
                        rowCount = 0;
                        if (itemSize < text.Length - 1)
                        {
                            itemSize++;
                        }
                        else
                        {
                            itemSize = 0;
                        }
                        break;
                    }

                    itemCount++; //X

                    if (itemCount > 15)
                    {
                        itemCount = 0;
                        rowCount = j / tableLenght; //Y
                    }
                }
            }

            foreach (var g in _glyphs)
            {
                batch.Draw(bitmapTex2D, new Rectangle((int)g.pos.X, (int)g.pos.Y, g.size, g.size), g.rect, color);
            }

            _glyphs.Clear();
        }

        /*public void Draw(SpriteBatch batch, int size, Vector2 position)
        {
            foreach (var g in _glyphs)
            {
                batch.Draw(bitmapTex2D, new Rectangle((int)g.pos.X, (int)g.pos.Y, 16, g.size), g.rect, Color.White);
            }
        }*/
    }
}