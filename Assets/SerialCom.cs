using System.Collections;
using UnityEngine;
using System.IO.Ports;

public class SerialCom : MonoBehaviour
{
    SerialPort data_stream = new SerialPort("COM6", 115200);
    public string receivedstring;

    public string[] datas;
    public float qw, qx, qy, qz;

    void Start()
    {
        data_stream.Open();
    }

    // Update is called once per frame
    void Update()
    {
        receivedstring = data_stream.ReadLine();

        datas = receivedstring.Split('\t');

        if (datas[1] != "" && datas[2] != "" && datas[3] != "" && datas[4] != "")
        {
            qw = float.Parse(datas[1]);
            qx = float.Parse(datas[2]);
            qy = float.Parse(datas[3]);
            qz = float.Parse(datas[4]);

            transform.rotation = new Quaternion(-qx, -qz, qy, qw);
        }
    }
}

