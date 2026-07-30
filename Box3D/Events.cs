using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Box3D;

[StructLayout(LayoutKind.Sequential)]
public struct BodyMoveEvent
{
    public IntPtr UserData;
    public Transform Transform;
    public BodyID BodyID;
    public Interop.NativeBool FellAsleep;
}

[StructLayout(LayoutKind.Sequential)]
public struct ContactBeginTouchEvent
{
    public ShapeID A;
    public ShapeID B;
    public ContactID ContactID;
}

[StructLayout(LayoutKind.Sequential)]
public struct ContactEndTouchEvent
{
    public ShapeID A;
    public ShapeID B;
    public ContactID ContactID;
}

[StructLayout(LayoutKind.Sequential)]
public struct ContactHitEvent
{
    public ShapeID A;
    public ShapeID B;
    public ContactID ContactID;
    public Vector3 Point;
    public Vector3 Normal;
    public float ApproachSpeed;
    public ulong UserMaterialIdA;
    public ulong UserMaterialIdB;
}

public readonly ref struct ContactEvents
{
    public readonly ReadOnlySpan<ContactBeginTouchEvent> BeginTouchEvents;
    public readonly ReadOnlySpan<ContactEndTouchEvent> EndTouchEvents;
    public readonly ReadOnlySpan<ContactHitEvent> HitEvents;

    internal ContactEvents(
        ReadOnlySpan<ContactBeginTouchEvent> beginTouchEvents,
        ReadOnlySpan<ContactEndTouchEvent> endTouchEvents,
        ReadOnlySpan<ContactHitEvent> hitEvents)
    {
        BeginTouchEvents = beginTouchEvents;
        EndTouchEvents = endTouchEvents;
        HitEvents = hitEvents;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct SensorBeginTouchEvent
{
    public ShapeID SensorShapeID;
    public ShapeID VisitorShapeID;
}

[StructLayout(LayoutKind.Sequential)]
public struct SensorEndTouchEvent
{
    public ShapeID SensorShapeID;
    public ShapeID VisitorShapeID;
}

public readonly ref struct SensorEvents
{
    public readonly ReadOnlySpan<SensorBeginTouchEvent> BeginTouchEvents;
    public readonly ReadOnlySpan<SensorEndTouchEvent> EndTouchEvents;

    internal SensorEvents(
        ReadOnlySpan<SensorBeginTouchEvent> beginTouchEvents,
        ReadOnlySpan<SensorEndTouchEvent> endTouchEvents)
    {
        BeginTouchEvents = beginTouchEvents;
        EndTouchEvents = endTouchEvents;
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct JointEvent
{
    public JointID jointId;
    public IntPtr userData;
}
