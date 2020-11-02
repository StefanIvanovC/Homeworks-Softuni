﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private const string textValidator = "{0} cannot be zero or negative.";


        private double lenght;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Lenght
        {
            get
            {
                return this.lenght;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Lenght cannot be zero or negative.");
                }
                this.lenght = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;

            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                this.width = value;

            }

        }

        public double Height
        {
            get
            {
                return this.height;

            }
            private set
            {
                if (height < 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
            
        }

        public double LateralSurfaceArea() => (2 * (this.lenght * this.height)) + (2 * (this.width * this.height));

        public double Volume() => this.lenght * this.height * this.width;

        public double SurfaceArea() => (2 * (this.lenght * this.width)) + (2 * (this.lenght * this.height)) + (2 * (this.width * this.height));

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {this.SurfaceArea():f2}")
                .AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}")
                .AppendLine($"Volume - {this.Volume():f2}");

            return sb.ToString().TrimEnd();
         }

        private void ValidateString(double side, string text)
        {
            if (side < 0)
            {
                throw new ArgumentException(String.Format(textValidator, nameof(side)));
            }
            
        }
    }
}
