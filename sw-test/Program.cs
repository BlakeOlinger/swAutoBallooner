using SldWorks;
using SwConst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sw_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var swInstance = new SldWorks.SldWorks();

            var part = (ModelDoc2)swInstance.ActiveDoc;
            var drawing = (DrawingDoc)part;

            var boolStatus = drawing.ActivateView("Drawing View1");

            boolStatus = part.Extension.SelectByID2("Drawing View1",
                "DRAWINGVIEW", 0, 0, 0, false, 0, null, 0);

            var autoballonParameters = drawing.CreateAutoBalloonOptions();

            autoballonParameters.Layout = (int)swBalloonLayoutType_e.swDetailingBalloonLayout_Square;
            autoballonParameters.ReverseDirection = false;
            autoballonParameters.IgnoreMultiple = true;
            autoballonParameters.InsertMagneticLine = true;
            autoballonParameters.LeaderAttachmentToFaces = true;
            autoballonParameters.Style = (int)swBalloonStyle_e.swBS_Box;
            autoballonParameters.Size = (int)swBalloonFit_e.swBF_2Chars;
            autoballonParameters.UpperTextContent = (int)swBalloonTextContent_e.swBalloonTextItemNumber;
            autoballonParameters.Layername = "Format";
            autoballonParameters.ItemNumberStart = 1;
            autoballonParameters.ItemNumberIncrement = 1;
            autoballonParameters.ItemOrder = (int)swBalloonItemNumbersOrder_e.swBalloonItemNumbers_DoNotChangeItemNumbers;
            autoballonParameters.EditBalloons = true;
            autoballonParameters.EditBalloonOption = (int)swEditBalloonOption_e.swEditBalloonOption_Resequence;

            var vNotes = drawing.AutoBalloon5(autoballonParameters);
        }
    }
}
