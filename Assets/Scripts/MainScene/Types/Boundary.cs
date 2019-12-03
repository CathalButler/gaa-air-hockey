    // A struct to group up, down, left & right floating point numbers:
    namespace MainScene.Types
    {
        struct Boundary
        {
            //Member Varaibles
            public float Up, Down, Left, Right;

            // Constrcutor
            public Boundary(float up, float down, float left, float right)
            {
                Up = up; Down = down; Left = left; Right = right;
            }// End Constrcutor

        }//End Struct
    }//End namespace
