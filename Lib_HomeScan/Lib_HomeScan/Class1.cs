//standard lib
using System;
using System.Collections.Generic;
using System.Text;
using PAT.Common.Classes.Expressions.ExpressionClass;
//have to use the following namespace
namespace PAT.Lib
{
    //define a datatype "Unitype" to express the data that we do not know which type it is
    public class Unitype : ExpressionValue
    {
		//define a set of public functions to check the datatype of the data
		private static List<Int32> intlist = new List<Int32>();

		public void setIntList(Int32 data){
			Console.WriteLine("TEST Lib !!!!!! defined intlist " + intlist);
			intlist.Add(data);
		}
		public List<Int32> getIntList() {
			return intlist;
		}
		//public bool IsConstant()
  //      {
  //          return this is Constant;
  //      }
       
  //      public virtual bool Constantequal(Constant i)
  //      {
  //          return false;
  //      }
     
        //define a public function to check the syntactical equality of two data
        public bool equal(Unitype i)
        {

			//if (this.IsConstant() == true && i.IsConstant() == true)
			//{
			//    return this.Constantequal((Constant)(Object)i);
			//}           
			//else return false;
			return true;
        }
        //standard methods that have to be included
        public override string ToString()
        {
            return "Unitype";
        }
        public override ExpressionValue GetClone()
        {
            return this;
        }
        public override string ExpressionID
        {
            get { return ""; }
        }
    }
    public class Knowledge: Unitype//List<Int32>
    {
       // public List<Int32> intlist = null;

        public Knowledge()
        {
           // intlist = new List<Int32>();
        }
        //define a function which tell whether using the attacher knowledge one can deduce the input type	
        public bool knows(Int32 i)
        {
            try
            {
                //if the input is null, there will be an execution error
                if (object.ReferenceEquals(i, null) || i == null)
                {
                    return false;
                }
                else
                {
                    //if the input is a constructor                
                    if (true)
                    {
                        Console.WriteLine("TEST Lib !!!!!! " + i);
                        Console.WriteLine("TEST Lib !!!!!! const list count " + getIntList().Count);
                        //if i exists in the initial adversary knowledge list, then the adversary knows it                        
                        if (getIntList().Contains(i) == true)
                        {
                            Console.WriteLine("TEST Lib !!!!!! YESSsss in init adv knowledge set");
                            return true;
                        }
                        else
                        {
                            //if i does not exisst in the initial adversary knowledge list, we try to see whether the adversary can deduce it from the inital adversary knowledge list                        
                            //return deduce(i);
                            Console.WriteLine("TEST Lib !!!!!! not in init adv knolwedge set" );
                            return false;
                        }
                    }
                    //if the input is a destructor
                    //Todo:remove it
                    
                    //else
                    //    return false;
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        //define a function to add knowledge into the inital adversary knowledge list(this function is called in the CSP# model)		
        public bool addKnowledge(Int32 i)
        {
            //if the input i is not already contained in the list
            if (!getIntList().Contains(i))
            {
				Console.WriteLine("TEST Lib !!!!!! addKnowledge " + i);
 

                if (true)
                {
					setIntList(i);
                    //ConstantList.Add((Constant)(object)i);
                    Console.WriteLine("TEST Lib !!!!!! addKnowledge list count " + getIntList().Count);
                    return true;

                }
            }
            else
                return false;
        }
    }
}

