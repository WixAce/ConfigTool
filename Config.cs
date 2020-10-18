using cn.bmob.io;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigTool
{
    public class Config : BmobTable
    {
        public string config1 { get; set; }

        public string config2 { get; set; }
        public string config3 { get; set; }
        public string config4 { get; set; }
        public string config5 { get; set; }
        public string config6 { get; set; }
        public string config7 { get; set; }

        public string config8 { get; set; }

        public string config9 { get; set; }
        
        public override void readFields(BmobInput input)
        {
            base.readFields(input);
            config1 = input.getString("config1");
            config2 = input.getString("config2");
            config3 = input.getString("config3");
            config4 = input.getString("config4");
            config5 = input.getString("config5");
            config6 = input.getString("config6");
            config7 = input.getString("config7");
            config8 = input.getString("config8");
            config9 = input.getString("config9");
        }

        public override void write(BmobOutput output, bool all)
        {
            base.write(output, all);
            output.Put("config1", this.config1);
            output.Put("config2", this.config2);
            output.Put("config3", this.config3);
            output.Put("config4", this.config4);
            output.Put("config5", this.config5);
            output.Put("config6", this.config6);
            output.Put("config7", this.config7);
            output.Put("config8", this.config8);
            output.Put("config9", this.config9);
        }
    }
}
