using GongSolutions.Wpf.DragDrop;
using System.Collections.ObjectModel;
using System.Windows;

namespace ManageLyrics
{
	public class ListDragDropViewModel //: IDropTarget
	{ }
	/*{
		public ObservableCollection<ListDragDropItemViewModel> Items;
		private ItemList items;

		public ListDragDropViewModel()
        {
			this.items = new ItemList();

		}

		public ItemList Items1
		{
			get { return this.items; }
		}

		void IDropTarget.DragOver(IDropInfo dropInfo)
		{
			ListDragDropItemViewModel sourceItem = dropInfo.Data as ListDragDropItemViewModel;
			ListDragDropItemViewModel targetItem = dropInfo.TargetItem as ListDragDropItemViewModel;

			if (sourceItem != null && targetItem != null && targetItem.CanAcceptChildren)
			{
				dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
				dropInfo.Effects = DragDropEffects.Copy;
			}
		}

		void IDropTarget.Drop(IDropInfo dropInfo)
		{
			ListDragDropItemViewModel sourceItem = dropInfo.Data as ListDragDropItemViewModel;
			ListDragDropItemViewModel targetItem = dropInfo.TargetItem as ListDragDropItemViewModel;
			targetItem.Children.Add(sourceItem);
		}
	}

	public class ListDragDropItemViewModel
	{
		public bool CanAcceptChildren { get; set; }
		public ObservableCollection<ListDragDropItemViewModel> Children { get; private set; }
	}
	*/
}
