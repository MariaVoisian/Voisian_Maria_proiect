using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Voisian_Maria_proiect
{
  
    class Alimente
    {
        
        private AlimenteType mFV;
    

        public AlimenteType FV
        {
            get
            {
                return mFV;
            }
            set
            {
                mFV = value;
            }
        }
        private float mPrice;
        public float Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }
        public Alimente(AlimenteType aFV) 
        {
            mFV = aFV;
        }
    }
    public enum AlimenteType
    {
        Apple,
        Banana,
        Lemon,
        Rasberry,
        Strawberry,
        Grapes,
        Pepper,
        Onion,
        Broccoli,
        Cauliflower
    }
    
}
