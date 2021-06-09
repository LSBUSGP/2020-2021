using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    public float UpdateTime = 1;
    public UILineRenderer UILR;
    public Text UICurFPS;
    public Text UIPastFPS;
    public Text UIMaxFPS;

    private float CurrentUpdateTime;
    private float CurrentFPS;
    private float PastFPS;
    private float CurrentFPS_Counter;
    private float GraphHeight;
    private float MaxFPS = 0;
    private float PointsYScale = 1;
    private float PointsYOffset = -1.5f;

    private string StoredUICurFPSText;
    private string StoredUIPastFPSText;

    private List<float> StoredFPS = new List<float>(0);

    // Start is called before the first frame update
    void Start()
    {
        GraphHeight = UILR.GridSize.y;

        StoredUICurFPSText = UICurFPS.text;
        StoredUIPastFPSText = UIPastFPS.text;

        Invoke("Run_UpdateFPS", UpdateTime);
    }

    void Update()
    {
        if (CurrentFPS_Counter < UpdateTime)
        {
            CurrentFPS_Counter += Time.smoothDeltaTime;
            CurrentUpdateTime++;
        }
        else
        {
            CurrentFPS = CurrentUpdateTime / CurrentFPS_Counter; 
            CurrentUpdateTime = 0;
            CurrentFPS_Counter = 0.0f;

            UICurFPS.text = StoredUICurFPSText + CurrentFPS.ToString("F2");
            UIPastFPS.text = StoredUIPastFPSText + PastFPS.ToString("F2");
            
            PastFPS = CurrentFPS;
        }
    }

    private void Run_UpdateFPS()
    {
        UpdateFPS();
    }

    private void UpdateFPS()
    {
        if(CurrentFPS > MaxFPS)
        {
            AdjustGraphScale();
        }

        StoredFPS.Add(CurrentFPS);
        UILR.Points.Add(new Vector2(UILR.Points.Count - 1, CurrentFPS * PointsYScale + PointsYOffset));
        if (UILR.Points.Count > UILR.GridSize.x) { ShiftPointsToLeft(); }
        UILR.SetAllDirty();


        Invoke("Run_UpdateFPS", UpdateTime);
    }

    private void ShiftPointsToLeft()
    {
        for(int i = 0; i < UILR.Points.Count - 1; i++)
        {
            UILR.Points[i] = new Vector2(UILR.Points[i].x - 1, UILR.Points[i].y);
        }

        UILR.Points.RemoveAt(0);
    }

    private void AdjustGraphScale()
    {
        MaxFPS = CurrentFPS;
        PointsYScale = GraphHeight / MaxFPS;
        UIMaxFPS.text = MaxFPS.ToString("F0");
    }
}
