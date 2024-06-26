using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    // 현재 점수와 연동해주기
    public int curScore;
    // 최고 점수와 연동해주기
    public int bestScore;
    public PlayerData playerData;
    public string key = "score";  // 암호화용 키

    public float masterVolume;
    public float bgmVolume;
    public float sfxVolume;


    protected override void Awake()
    {
        base.Awake();

        OnLoadData();
    }

    public void InitData()
    {
        GameManager.instance.Player.DieEvent += RecordScore;
    }

    public void RecordScore()
    {
        curScore = GameManager.instance.score;
        if (curScore > bestScore)
        {
            bestScore = curScore;
            GameManager.instance.bestScoreTxt.text = bestScore.ToString();
        }
        OnSaveData();
    }

    public void OnSaveData()
    {
        DataSerialize();

        var json = JsonUtility.ToJson(playerData);
        json = AESWithJava.Con.Program.Encrypt(json, key);  // 암호화
        File.WriteAllText(Application.persistentDataPath + "/UserData.json", json);
    }

    private void DataSerialize()
    {
        playerData.bestScore = bestScore;
        playerData.masterVolume = masterVolume;
        playerData.bgmVolume = bgmVolume;
        playerData.sfxVolume = sfxVolume;
    }

    public void OnLoadData()
    {
        if (!File.Exists(Application.persistentDataPath + "/UserData.json"))
            return;

        var jsonData = File.ReadAllText(Application.persistentDataPath + "/UserData.json");
        jsonData = AESWithJava.Con.Program.Decrypt(jsonData, key);  // 복호화
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);

        DataDeserialize();
    }

    private void DataDeserialize()
    {
        bestScore = playerData.bestScore;
        masterVolume = playerData.masterVolume;
        bgmVolume = playerData.bgmVolume;
        sfxVolume = playerData.sfxVolume;
    }
}

[System.Serializable]
public class  PlayerData
{
    public int bestScore;

    public float masterVolume;
    public float bgmVolume;
    public float sfxVolume;
}

namespace AESWithJava.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            String originalText = "plain text";
            String key = "key";
            String en = Encrypt(originalText, key);
            String de = Decrypt(en, key);

            Console.WriteLine("Original Text is " + originalText);
            Console.WriteLine("Encrypted Text is " + en);
            Console.WriteLine("Decrypted Text is " + de);
        }

        public static string Decrypt(string textToDecrypt, string key)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;

            rijndaelCipher.KeySize = 128;
            rijndaelCipher.BlockSize = 128;
            byte[] encryptedData = Convert.FromBase64String(textToDecrypt);
            byte[] pwdBytes = Encoding.UTF8.GetBytes(key);
            byte[] keyBytes = new byte[16];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length)
            {
                len = keyBytes.Length;
            }
            Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            rijndaelCipher.IV = keyBytes;
            byte[] plainText = rijndaelCipher.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            return Encoding.UTF8.GetString(plainText);
        }

        public static string Encrypt(string textToEncrypt, string key)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;

            rijndaelCipher.KeySize = 128;
            rijndaelCipher.BlockSize = 128;
            byte[] pwdBytes = Encoding.UTF8.GetBytes(key);
            byte[] keyBytes = new byte[16];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length)
            {
                len = keyBytes.Length;
            }
            Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            rijndaelCipher.IV = keyBytes;
            ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(textToEncrypt);
            return Convert.ToBase64String(transform.TransformFinalBlock(plainText, 0, plainText.Length));
        }
    }
}