using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    // TEAM
    public TMP_Dropdown teamNumberInput;
    public TMP_InputField numberOfBatteriesInput;
    public TMP_InputField robotWidthInput;
    public TMP_InputField robotLengthInput;
    public TMP_InputField robotWeightInput;
    public Toggle dedicatedDriveteamInput;
    public TMP_Dropdown behaviorInput;
    public TMP_Dropdown driveTrainInput;
    public TMP_InputField teamOther;

    // AUTO
    public TMP_Dropdown positionInput;
    public TMP_Dropdown chargingStationInput;
    public Toggle secondPieceInput;
    public Toggle leftCommunityInput;
    public TMP_InputField autoOther;

    // TELEOP
    public TMP_Dropdown prefPositionInput;
    public TMP_Dropdown prefChargingStationInput;
    public TMP_Dropdown prefCollectionInput;
    public TMP_Dropdown prefPieceScoreInput;
    public Toggle SideCones;
    public TMP_InputField teleOther;

    // SCREENS
    public GameObject teamScreen;
    public GameObject autoScreen;
    public GameObject teleopScreen;

    // OTHER

    public GameObject noTeamPopup;

    private void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        };
        teamScreen.SetActive(true);
        autoScreen.SetActive(false);
        teleopScreen.SetActive(false);
    }

    public void Team()
    {
        teamScreen.SetActive(true);
        autoScreen.SetActive(false);
        teleopScreen.SetActive(false);
    }

    public void Auto()
    {
        teamScreen.SetActive(false);
        autoScreen.SetActive(true);
        teleopScreen.SetActive(false);
    }

    public void Teleop()
    {
        teamScreen.SetActive(false);
        autoScreen.SetActive(false);
        teleopScreen.SetActive(true);
    }


    public void Load()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite)) {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        };
    }

    public void Ok()
    {
        Team();
        noTeamPopup.SetActive(false);
    }

    public void Submit()
    {
        if (teamNumberInput.value == 0)
        {
            noTeamPopup.SetActive(true);
            return;
        }

        string fileText = "Team Number,Number of Batteries,Width,Length,Weight,Drive Team,Behavior,DriveTrain,TeamOther\n" +
        teamNumberInput.captionText.text + "," +
        numberOfBatteriesInput.GetComponent<TMP_InputField>().text + "," +
        robotWidthInput.GetComponent<TMP_InputField>().text + "," +
        robotWidthInput.GetComponent<TMP_InputField>().text + "," +
        robotWeightInput.GetComponent<TMP_InputField>().text + "," +
        dedicatedDriveteamInput.isOn + "," +
        //behaviorInput.captionText.text + "," +
        driveTrainInput.captionText.text + "," +
        teamOther.GetComponent<TMP_InputField>().text + "\n";
        /*positionInput.captionText.text + "," +
        chargingStationInput.captionText.text + "," +
        secondPieceInput.isOn + "," +
        leftCommunityInput.isOn + "," +
        autoOther.GetComponent<TMP_InputField>().text + "," +
        prefPositionInput.captionText.text + "," +
        prefChargingStationInput.captionText.text + "," +
        prefCollectionInput.value + "," +
        prefPieceScoreInput.captionText.text + "," +
        SideCones.isOn + "," +
        teleOther.GetComponent<TMP_InputField>().text+"\n"; */

        string path = "/sdcard/Documents/" + teamNumberInput.captionText.text + ".csv";
        File.WriteAllText(path, fileText);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}