using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA.Algorithms.Data.UnionFind
{
    public class UnionFind<T> where T : class, IUnionFindId
    {
        public UnionFind()
        {
            items = new Dictionary<int, T>();
            groups = new Dictionary<int, List<int>>();
        }

        private Dictionary<int, T> items;
        private Dictionary<int, List<int>> groups;

        public int? GetClusterId(int elementId)
        {
            if (items.ContainsKey(elementId))
            {
                return items[elementId].LeaderId;
            }

            return null;
        }

        public void AddElement(T item, int leaderId)
        {
            if (!items.ContainsKey(item.Id))
            {
                item.LeaderId = leaderId;

                items.Add(item.Id, item);
                
                if (groups.ContainsKey(item.LeaderId))
                {
                    groups[item.LeaderId].Add(item.Id);
                }
                else
                {
                    if (item.Id == item.LeaderId)
                    {
                        groups.Add(item.Id, new List<int>{item.Id});
                    }
                    else
                    {
                        throw new Exception("Add new group without leader");
                    }
                }
            }
        }

        public void MergeGroups(int leader1, int leader2)
        {
            if (leader1 != leader2)
            {
                if (groups.ContainsKey(leader1) && groups.ContainsKey(leader2))
                {
                    int minGroupId = groups[leader1].Count < groups[leader2].Count ? leader1 : leader2;
                    int maxGroupId = groups[leader1].Count >= groups[leader2].Count ? leader1 : leader2;

                    for (int i = 0; i < groups[minGroupId].Count; i++)
                    {
                        var itemId = groups[minGroupId][i];
                        groups[maxGroupId].Add(itemId);

                        items[itemId].LeaderId = maxGroupId;
                    }

                    groups.Remove(minGroupId);
                }
                else
                {
                    throw new Exception("No such groups");
                }
            }
        }

        public int GroupsCount
        {
            get { return groups.Count; }
            private set { }
        }
    }
}
