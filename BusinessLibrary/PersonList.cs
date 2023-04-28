﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;

namespace BusinessLibrary
{
  [Serializable]
  public class PersonList : ReadOnlyListBase<PersonList, PersonInfo>
  {
    [Create, RunLocal]
    private void Create() { }

    [Fetch]
    private void Fetch([Inject]DataAccess.IPersonDal dal, [Inject]IChildDataPortal<PersonInfo> personPortal)
    {
      IsReadOnly = false;
      var data = dal.Get().Select(d => personPortal.FetchChild(d));
      AddRange(data);
      IsReadOnly = true;
    }
  }
}
