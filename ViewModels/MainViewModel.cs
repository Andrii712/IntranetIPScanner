using IntranetIPScanner.Commands;
using IntranetIPScanner.Models;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace IntranetIPScanner.ViewModels
{
    /// <summary>
    /// Interaction logig for MainViewModel.
    /// </summary>
    public class MainViewModel : BindableBase
    {
        private ScannerModel scanner;

        public MainViewModel()
        {
            scanner = new ScannerModel 
            { 
                IPRangeStart = "192.168.1.1", 
                IPRangeEnd = "192.168.1.255", 
                Hostname = System.Net.Dns.GetHostName() 
            };
        }

        public ObservableCollection<ScannerModel> IPAddressesList { get; set; }

        public string IPRangeStart
        {
            get => scanner.IPRangeStart;
            set
            {
                if (IsIPAddress(value))
                    SetProperty<ScannerModel, string>(ref scanner, value, nameof(IPRangeStart));
            }
        }
        public string IPRangeEnd
        {
            get => scanner.IPRangeEnd;
            set
            {
                if (IsIPAddress(value))
                    SetProperty<ScannerModel, string>(ref scanner, value, nameof(IPRangeEnd));
            }
        }

        public string Hostname
        {
            get => scanner.Hostname;
            set
            {
                SetProperty<ScannerModel, string>(ref scanner, value, nameof(Hostname));
            }
        }

        /// <summary>
        /// Checks the input value is correct.
        /// </summary>
        /// <param name="input">The string to search for a disallowed match and null or empty value.</param>
        /// <returns>true if the regular expression finds a match (the input value is IP Address); otherwise, false.</returns>
        bool IsIPAddress(string input)
        {
            // The regular expression pattern that matches disallowed text.
            string pattern = "^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";

            if (String.IsNullOrEmpty(input) || (!Regex.IsMatch(input, pattern)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #region ButtonCommands
        public ICommand Start => new StartCommand(); 
        #endregion
    }
}
