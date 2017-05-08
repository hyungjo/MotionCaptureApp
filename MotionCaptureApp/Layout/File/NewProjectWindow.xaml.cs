using MotionCaptureApp.Model;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MotionCaptureApp.Layout.File
{
    /// <summary>
    /// NewProjectWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NewProjectWindow : Window
    {
        private string currentProjectLocation;
        private List<ProcessModel> processModelList;
        private List<WorkerModel> workerModelList;

        public NewProjectWindow()
        {
            InitializeComponent();

            processModelList = new List<ProcessModel>();
            workerModelList = new List<WorkerModel>();
        }

        private void ProjectLocationSelectBtn_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                ProjectLocationTxt.Text = dialog.FileName + "\\" + ProjectNameTxt.Text;
                currentProjectLocation = dialog.FileName;
            }
        }

        private void ProjectNameTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProjectLocationTxt.Text = string.Empty;

            ProjectLocationTxt.Text = currentProjectLocation + "\\" + ProjectNameTxt.Text;
        }

        private void ProcessItemInsertBtn_Click(object sender, RoutedEventArgs e)
        {
            processModelList.Add(new ProcessModel(ProcessNameTxt.Text, ProcessExplanationTxt.Text));
   
            ProcessDg.ItemsSource = processModelList;
            ProcessDg.Items.Refresh();

            ProcessNameTxt.Text = string.Empty;
            ProcessExplanationTxt.Text = string.Empty;
        }

        private void WorkerItemInsertBtn_Click(object sender, RoutedEventArgs e)
        {
            workerModelList.Add(new WorkerModel(
                WorkerNameTxt.Text, Convert.ToInt16(WorkerAgeTxt.Text), Convert.ToInt16(WorkerGenderCmb.SelectedIndex),
                Convert.ToDouble(WorkerHeightTxt.Text), Convert.ToDouble(WorkerWeightTxt.Text), "TEST"
                ));

            WorkerDg.ItemsSource = workerModelList;
            WorkerDg.Items.Refresh();

            WorkerNameTxt.Text = string.Empty;
            WorkerAgeTxt.Text = string.Empty;
            WorkerHeightTxt.Text = string.Empty;
            WorkerWeightTxt.Text = string.Empty;
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current as App).DBConnection.executeInsertQuery(processModelList.ToList<ModelInterface>());
            (Application.Current as App).DBConnection.executeInsertQuery(workerModelList.ToList<ModelInterface>());

            this.Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        ///TODO
        ///Control Validation 구현
        ///참고: http://stackoverflow.com/questions/19539492/wpf-textbox-validation-c-sharp
    }
}
