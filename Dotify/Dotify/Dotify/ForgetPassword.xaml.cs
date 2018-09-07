using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dotify
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgetPassword : ContentPage
    {
        int firstPass = 0;
        public ForgetPassword()
        {
            if (firstPass == 0)
            {
                SelectQuestions();
                firstPass = 1;
            }
            else
            {
                var verifyButton = ButtonVerify;
                verifyButton.Clicked += async (sender, e) =>
                {
                    //If true 
                        //Give the user a new password 
                    //If false
                        //Randdomize the questions and prompt the user to answer again
                    SelectQuestions();
                    await Navigation.PopAsync();
                };
            }
            InitializeComponent();
        }

        /**
         * A method that parses the JSON File for the security questions that the user
         * created when they first created their account. 
         * 
         **/
        public void SelectQuestions()
        {
            //Parse the JSON Files and retrieve the four questions
            //From the four, select a random 2
            FirstQuestion.Text = "This is the First Question";
            SecondQuestion.Text = "This is the Second Quesiton";
        }

    }
}

