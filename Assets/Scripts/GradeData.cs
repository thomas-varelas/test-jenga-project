using System;
using System.Collections.Generic;

[Serializable]
public class GradeData
{
    public int id;
    public string subject;
    public string grade;
    public int mastery;
    public string domainid;
    public string domain;
    public string cluster;
    public string standardid;
    public string standarddescription;
}

[Serializable]
public class NoNameRootJSON
{
    public GradeData[] data;
}

public class CustomDataComparer : IComparer<GradeData>
{
    public int Compare(GradeData x, GradeData y)
    {
        if (x.domain.CompareTo(y.domain) == 0)
        {
            if(x.cluster.CompareTo(y.cluster) == 0)
            {
                return x.id.CompareTo(y.id);
            }
            else
            {
                return x.cluster.CompareTo(y.cluster);
            }
        }
        else
        {
            return x.domain.CompareTo(y.domain);
        }
    }
}
