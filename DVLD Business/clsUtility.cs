using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsUtility
    {

        public static string errorSaveMessage = "An error occurred while saving the data.";
       
        public static string errorSaveTitle = "Save error";

        public static string saveMessage(string entity)
        {
            return "The " + entity + " has been saved successfully.";
        }
        public static string saveTitle(string entity)
        {
            return entity + " saved";
        }

    }
}
