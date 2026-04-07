namespace LeetCode.Library.Algorithms;

public class Robot {
    private readonly int _width;
    private readonly int _height;
    private int _x = 0;
    private int _y = 0;
    private int _dir = 0; // 0: east, 1: south, 2: west, 3: north
    private static readonly int[] Dx = [1, 0, -1, 0];
    private static readonly int[] Dy = [0, -1, 0, 1];
    private static readonly string[] DirNames = ["East", "South", "West", "North"];
    private readonly int _cycleLen;
    private readonly int[] _xByStep;
    private readonly int[] _yByStep;
    private readonly int[] _dirByStep;
    private long _stepCnt = 0;

    public Robot(int width, int height) {
        _width = width;
        _height = height;
        _cycleLen = 2 * (width + height) - 4;

        _xByStep = new int[_cycleLen];
        _yByStep = new int[_cycleLen];
        _dirByStep = new int[_cycleLen];
        BuildLookupTables();
    }

    private bool CannotMoveForward(int x, int y, int dir) {
        Span<int> remaining = stackalloc int[4] { _width - 1 - x, y, x, _height - 1 - y };
        return remaining[dir] == 0;
    }

    private void BuildLookupTables() {
        int x = 0, y = 0, dir = 0;
        _xByStep[0] = 0;
        _yByStep[0] = 0;
        _dirByStep[0] = 0;

        for (int step = 1; step < _cycleLen; step++) {
            x += Dx[dir];
            y += Dy[dir];
            _xByStep[step] = x;
            _yByStep[step] = y;
            _dirByStep[step] = dir;

            if (CannotMoveForward(x, y, dir)) {
                dir = (dir + 3) % 4;
            }
        }
    }
    
    public void Step(int num) {
        if (_cycleLen <= 0) {
            return;
        }

        _stepCnt += num;
        int normalized = (int)(_stepCnt % _cycleLen);

        if (normalized == 0 && _stepCnt > 0) {
            _x = 0;
            _y = 0;
            _dir = 1;
            return;
        }

        _x = _xByStep[normalized];
        _y = _yByStep[normalized];
        _dir = _dirByStep[normalized];
    }
    
    public int[] GetPos() {
        return new int[] { _x, _y };
    }
    
    public string GetDir() {
        return DirNames[_dir];
    }
}

public class Lc2069Solution {
    private Robot _robot = null!;
    public void Robot(int width, int height) {
        _robot = new Robot(width, height);
    }
    public void Step(int num) {
        _robot.Step(num);
    }
    
    public int[] GetPos() {
        return _robot.GetPos();
    }
    
    public string GetDir() {
        return _robot.GetDir();
    }
}