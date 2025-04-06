using UnityEngine;

public interface IsMoveable
{
    Rigidbody2D RB { get; set; }
    bool HaveWayPoint { get; set; }


    //bool IsFacingRight { get; set; }
    //void Movehero(Vector2 velocity);
    //void CheckForLeftOrRightFacing(Vector2 velocity);
}
