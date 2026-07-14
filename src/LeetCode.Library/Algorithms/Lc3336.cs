namespace LeetCode.Library.Algorithms;

public class Lc3336Solution {
    private static int[][] GCD = new int[201][];
    private static int[][] dp = new int[2][];
    private void initCache() {
        int N = 201;
        if (GCD[0] != null) {
            return;
        }
        dp[0] = new int[N * N];
        dp[1] = new int[N * N];
        for(int x=0; x<N; x++)
        {
            GCD[x] = new int[N];
            GCD[x][x] = GCD[x][0] = GCD[0][x] = x;
        }
        
        for(int x=1; x<N; x++){
            GCD[x][1]=GCD[1][x]=1;
            for(int y=2; y<x; y++){
                GCD[x][y]=GCD[y][x]=GCD[y][x-y];
            }
        }
    }
    public int SubsequencePairCount(int[] nums) {
        initCache();
        int mod = 1000000007;
        int n = nums.Length;
        int M = 0;
        for(int i=0; i<n; i++){
            M = Math.Max(M, nums[i]);
        }
        int M2 = (M + 1) * (M + 1);
        Array.Clear(dp[0], 0, M2);
        dp[0][0] = 1;
        for(int i=0; i<n; i++){
            int x=nums[i];
            int cur=i&1, nxt= 1 - cur;
            Array.Clear(dp[nxt], 0, M2);

            for(int g1=0; g1<=M; g1++){
                for(int g2=0; g2<=M; g2++){
                    if (dp[cur][g1*(M+1)+g2]==0) continue;
                    long curDp = dp[cur][g1*(M+1)+g2];
                    int ng1 = GCD[g1][x];
                    dp[nxt][ng1*(M+1)+g2]=(int)((dp[nxt][ng1*(M+1)+g2]+curDp)%mod);

                    int ng2 = GCD[g2][x];
                    dp[nxt][g1*(M+1)+ng2]=(int)((dp[nxt][g1*(M+1)+ng2]+curDp)%mod);

                    dp[nxt][g1*(M+1)+g2]=(int)((dp[nxt][g1*(M+1)+g2]+curDp)%mod);
                }
            }
        }
        int last=n&1;
        long ans = 0;
        for(int i=1; i<=M; i++) ans+=dp[last][i*(M+2)];
        return (int)(ans%mod);
    }
}