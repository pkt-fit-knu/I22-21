namespace Bilinear_interpolation
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.new_img_box = new Emgu.CV.UI.ImageBox();
            this.zoom_img_block = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.new_img_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoom_img_block)).BeginInit();
            this.SuspendLayout();
            // 
            // new_img_box
            // 
            this.new_img_box.Location = new System.Drawing.Point(12, 12);
            this.new_img_box.Name = "new_img_box";
            this.new_img_box.Size = new System.Drawing.Size(500, 500);
            this.new_img_box.TabIndex = 30;
            this.new_img_box.TabStop = false;
            // 
            // zoom_img_block
            // 
            this.zoom_img_block.Location = new System.Drawing.Point(521, 12);
            this.zoom_img_block.Name = "zoom_img_block";
            this.zoom_img_block.Size = new System.Drawing.Size(500, 500);
            this.zoom_img_block.TabIndex = 31;
            this.zoom_img_block.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1033, 522);
            this.Controls.Add(this.zoom_img_block);
            this.Controls.Add(this.new_img_box);
            this.Name = "Form1";
            this.Text = "Білінійна інтерполяція";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.new_img_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoom_img_block)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox new_img_box;
        private Emgu.CV.UI.ImageBox zoom_img_block;
    }
}

