using System;
using System.Collections.Generic;
using System.Text;

namespace HolePunching.Services
{
    class Menu
    {
        public void show() {
            Console.Clear();

            string logo = @"

.______        ______     ______  __  ___ ____    ____ 
|   _  \      /  __  \   /      ||  |/  / \   \  /   / 
|  |_)  |    |  |  |  | |  ,----'|  '  /   \   \/   /  
|      /     |  |  |  | |  |     |    <     \_    _/   
|  |\  \----.|  `--'  | |  `----.|  .  \      |  |     
| _| `._____| \______/   \______||__|\__\     |__|     

specify targer and source data in conf.xml
                                                       

";
            Console.WriteLine(logo);
            string opt = @"


[0]  send punch packet
[1]  send regular packet through hole
[2]  boot sender
[3]  boot listener


";
            Console.WriteLine(opt);
            Console.Write("select option:");
            this.choice = Console.ReadLine().Trim();                
        }

        public string choice { get; set; }

    }
}
