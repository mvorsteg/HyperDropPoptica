using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour
{
    [Tooltip("Instructions Format:\n`rotation,numProjectiles,spreadAngle,spreadOffsetAngle`\n`rotation,numProjectiles,spreadAngle,spreadOffsetAngle`\n...")]
    [TextArea]
    public string instructions;
    private TurretInstruction[] instructs;

    void Awake()
    {
        string[] singleInstructs = instructions.Split('\n');
        instructs = new TurretInstruction[singleInstructs.Length];
        
        for (int i = 0; i < singleInstructs.Length; i++)
        {
            string[] currInstruct = singleInstructs[i].Split(',');
            instructs[i].rotation = float.Parse(currInstruct[0]);
            instructs[i].numProjectiles = int.Parse(currInstruct[1]);
            instructs[i].spread = float.Parse(currInstruct[2]);
            instructs[i].spreadOffset = float.Parse(currInstruct[3]);
        }
        GetComponent<SimpleTurret>().BeginTurret(instructs);
    }

}