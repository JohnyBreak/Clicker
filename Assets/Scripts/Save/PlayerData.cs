using Newtonsoft.Json;
using System.Collections.Generic;

public class PlayerData
{
    //private string _selectedSkinID;

    //private List<string> _openItemIDs;

    private int _clickAmount;

    public int ClickAmount
    {
        get => _clickAmount;
        set
        {
            if (value < 0) throw new System.ArgumentOutOfRangeException(nameof(value));

            _clickAmount = value;
        }
    }

    //public string SelectedSkinID
    //{
    //    get => _selectedSkinID;
    //    set
    //    {
    //        if (_openItemIDs.Contains(value) == false)
    //            throw new System.ArgumentException(nameof(value));

    //        _selectedSkinID = value;
    //    }
    //}

    public PlayerData()
    {
        //_openItemIDs = new List<string>();
    }

    [JsonConstructor]
    public PlayerData(int tickets, string selectedSkinID, List<string> openedItemID)
    {
        _clickAmount = tickets;
        //_selectedSkinID = selectedSkinID;
        //_openItemIDs = openedItemID ?? new List<string>();
    }

    //public IEnumerable<string> OpenItemIDs => _openItemIDs;

    //public void OpenItem(string asset)
    //{
    //    if (_openItemIDs.Contains(asset))
    //        throw new System.ArgumentException(nameof(asset));

    //    _openItemIDs.Add(asset);
    //}

    //public bool ItemIsOpen(string id)
    //{
    //    return _openItemIDs.Contains(id);
    //}
}
