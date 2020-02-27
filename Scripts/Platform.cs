using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

class Platform : MonoBehaviour, IScaleChangeableeState
{
    public InternalBatteryCover[] internalBatteryCovers;
    public InternalBatteryCover internalBatteryCoversCenter;
    public ExternalBatteryCover[] externalBatteryCovers;
    public ExternalBatteryCover externalBatteryCoverCenter;
    public Battery[] batteries;
    public Battery batteriesCenter;
    public BatteryContainer[] batteryContainers;
    public BatteryContainer batteryContainersCenter;
    public CoverFrame coverFrame;
    public CoverLock coverLock;
    public TopCover topCover;
    public BottomCover bottomCover;
    public Motorama[] motoramas;
    public AdditionalEngineMount[] additionalEngineMounts;
    public ControlBoardMountingFrame controlBoardMountingFrame;
    public BackCover backCover;
    public Switch switchPlatform;
    public FrontCover frontCover;
    public SideCover[] sideCovers;
    public InfraredSensor[] infraredSensors;
    public InfraredSensor infraredSensorsCenter;
    public AdditionalFastener[] additionalFasteners;
    public AdditionalFastener additionalFastenersCenter;
    public WheelEngine[] wheelEngines;
    public WheelDrive[] wheelDrives;
    public WheelClutch[] wheelClutches;
    public WheelRubber[] wheelRubbers;
    public ControlBoard controlBoard;
    public UltrasonicSensor[] ultrasonicSensors;
    public UltrasonicSensor ultrasonicSensorsCenter;
    public BallBearing ballBearing;
    public BottomSolenoidMount bottomSolenoidMount;
    public SideSolenoidMount[] sideSolenoidMounts;
    public BackSolenoidCover backSolenoidCover;
    public FrontSolenoidCover frontSolenoidCover;
    public Solenoid solenoid;
    public SolenoidBox solenoidBox;
    public FemaleScrew femaleScrew;

    private Detail[][] multipleDetails;
    private Detail[] singleParts;

    public void Start()
    {

        singleParts = new Detail[] { coverFrame, coverLock, topCover, bottomCover, controlBoardMountingFrame,
                                     backCover, switchPlatform, frontCover, controlBoard, ballBearing,
                                     bottomSolenoidMount, backSolenoidCover, frontSolenoidCover,
                                     solenoid, solenoidBox, femaleScrew,externalBatteryCoverCenter,
                                     internalBatteryCoversCenter,batteriesCenter, batteryContainersCenter,
                                     ultrasonicSensorsCenter, additionalFastenersCenter, infraredSensorsCenter
        };

        multipleDetails = new Detail[][] {
                                   motoramas, additionalEngineMounts, sideCovers,
                                   wheelEngines, wheelDrives, wheelClutches,
                                   wheelRubbers, sideSolenoidMounts

        };
    }

    public void Compress()
    {
        for(int i = 0; i < singleParts.Length; i++)
        {
            StartCoroutine(singleParts[i].MoveFromEndToBegin());
        }

        for (int i = 0; i < multipleDetails.Length; i++)
        {
            for(int j = 0; j < multipleDetails[i].Length; j++)
            {
                StartCoroutine(multipleDetails[i][j].MoveFromEndToBegin());
            }
        }
    }

    public void Expand()
    {
        for (int i = 0; i < singleParts.Length; i++)
        {
            StartCoroutine(singleParts[i].MoveFromBeginToEnd());
        }

        for (int i = 0; i < multipleDetails.Length; i++)
        {
            for (int j = 0; j < multipleDetails[i].Length; j++)
            {
                StartCoroutine(multipleDetails[i][j].MoveFromBeginToEnd());
            }
        }
    }
}