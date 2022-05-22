using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestListTemplate
{
    public class TestComboViewModel
    {
            public List<TestComboModel> Students { get; set; }
 
            public TestComboViewModel()
            {
                Students = new List<TestComboModel>()
            {
                new TestComboModel(){ID = "1", Name = "범범조조", Age = 29},
                new TestComboModel(){ID = "2", Name = "아이유", Age = 20},
                new TestComboModel(){ID = "3", Name = "정형돈", Age = 49},
                new TestComboModel(){ID = "4", Name = "유재석", Age = 39},
            };
            }
    }
}
