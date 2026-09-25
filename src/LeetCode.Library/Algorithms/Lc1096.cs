using System;
using System.Text;
namespace LeetCode.Library.Algorithms;

public class Lc1096Solution {
    private List<char> op = [];
    private List<HashSet<string>> st = [];
    private void perf() {
        int x = st.Count - 2, y = st.Count - 1;
        if (op[^1] == '+'){
            // Union (HashSet dedupes as we merge)
            st[x].UnionWith(st[y]);
        }
        else { // op.back()=='*'
            // Concatenation, deduped so duplicates don't compound in later steps
            HashSet<string> nxt = new HashSet<string>(st[x].Count * st[y].Count);
            foreach (var l in st[x]) {
                foreach (var r in st[y]) {
                    nxt.Add(l + r);
                }
            }
            st[x] = nxt;
        }
        op.RemoveAt(op.Count -1);
        st.RemoveAt(st.Count - 1);
    }
    public IList<string> BraceExpansionII(string expression) {
        int n = expression.Length;
        op = new List<char>(n);
        st = new List<HashSet<string>>(n);

        char prv='@', cur;

        for (int i=0; i < n; i++, prv = cur) {
            cur = expression[i];
            switch (cur) {
            case ',': 
                while (op.Count > 0 && op[^1] != '{')
                {
                    perf();
                }
                op.Add('+');
                break;
            case '{':
                if (prv == '}' || char.IsLetter(prv))
                {
                    op.Add('*');
                }
                op.Add('{');
                break;
            case '}':
                while (op.Count > 0 && op[^1] !='{')
                {
                    perf();    
                }
                    
                op.RemoveAt(op.Count - 1); // Remove matching '{'
                break;
            default:
                if (prv=='}')
                {
                    op.Add('*');
                }
                StringBuilder sb = new StringBuilder();
                for (; i < n &&  char.IsLetter(expression[i]); i++)
                {
                    sb.Append(expression[i]);
                }
                st.Add([sb.ToString()]);
                i--;
                cur = expression[i];
                break;
            }
        }

        while (op.Count > 0)
        {
            perf();
        }
        var ans = new List<string>(st[0]);
        ans.Sort();
        return ans;
    }
}