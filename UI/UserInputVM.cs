using System.ComponentModel.DataAnnotations;

namespace WPF
{
    /// <summary>
    /// This class inherits from the ObservableObject class and validates the user input based on the defined conditions
    /// as and when there is a change in the user input.
    /// <summary>
    public class UserInputVM : ObservableObject
    {
        /// <summary>
        /// Validates the user input for the X component of the first vector
        /// <summary>
        private string _v1_X;

        [Required(ErrorMessage = "Input required")]
        [RegularExpression(@"^[+-]?(\d+)?\.?(\d+)?$", ErrorMessage = "Must be a valid number")]
        public string V1_X
        {
            get { return _v1_X; }
            set
            {
                ValidateProperty(value, "V1_X");
                OnPropertyChanged(ref _v1_X, value);
            }
        }

        /// <summary>
        /// ValidateProperty method to validate the user input 
        /// <summary>
        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }

        /// <summary>
        /// Validates the user input for the Y component of the first vector
        /// <summary>
        private string _v1_Y;

        [Required(ErrorMessage = "Input required")]
        [RegularExpression(@"^[+-]?\d+\.?(\d+)?$", ErrorMessage = "Must be a valid number")]
        public string V1_Y
        {
            get { return _v1_Y; }
            set
            {
                ValidateProperty(value, "V1_Y");
                OnPropertyChanged(ref _v1_Y, value);
            }
        }

        /// <summary>
        /// Validates the user input for the Z component of the first vector
        /// <summary>
        private string _v1_Z;

        [Required(ErrorMessage = "Input required")]
        [RegularExpression(@"^[+-]?\d+\.?(\d+)?$", ErrorMessage = "Must be a valid number")]
        public string V1_Z
        {
            get { return _v1_Z; }
            set
            {
                ValidateProperty(value, "V1_Z");
                OnPropertyChanged(ref _v1_Z, value);
            }
        }

        /// <summary>
        /// Validates the user input for the X component of the second vector
        /// <summary>
        private string _v2_X;

        [Required(ErrorMessage = "Input required")]
        [RegularExpression(@"^[+-]?\d+\.?(\d+)?$", ErrorMessage = "Must be a valid number")]
        public string V2_X
        {
            get { return _v2_X; }
            set
            {
                ValidateProperty(value, "V2_X");
                OnPropertyChanged(ref _v2_X, value);
            }
        }

        /// <summary>
        /// Validates the user input for the Y component of the second vector
        /// <summary>
        private string _v2_Y;

        [Required(ErrorMessage = "Input required")]
        [RegularExpression(@"^[+-]?\d+\.?(\d+)?$", ErrorMessage = "Must be a valid number")]
        public string V2_Y
        {
            get { return _v2_Y; }
            set
            {
                ValidateProperty(value, "V2_Y");
                OnPropertyChanged(ref _v2_Y, value);
            }
        }

        /// <summary>
        /// Validates the user input for the Z component of the second vector
        /// <summary>
        private string _v2_Z;

        [Required(ErrorMessage = "Input required")]
        [RegularExpression(@"^[+-]?\d+\.?(\d+)?$", ErrorMessage = "Must be a valid number")]
        public string V2_Z
        {
            get { return _v2_Z; }
            set
            {
                ValidateProperty(value, "V2_Z");
                OnPropertyChanged(ref _v2_Z, value);
            }
        }

    }
}
