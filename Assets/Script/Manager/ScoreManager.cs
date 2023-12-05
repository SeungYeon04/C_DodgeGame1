using UnityEngine;

public class ScoreManager
{
    public int RemainKill { get; private set; }
    public int Kill { get; private set; }

    public ScoreManager(int remainKill, int kill)
    {
        RemainKill = remainKill;
        Kill = kill;
    }

    private void AchieveScore()
    {
        Debug.Log("achieve kill");
        this.RemainKill = 10;
        //GameManager.Enemy.SpawnMonster();
        //Enemy�� �������� ������ ���� ������ �ڵ� ������ �ϴ� �뵵�� method ����
        //�Է� ���� method ��� -> �ش� method�� Ÿ method ȣ���Ͽ� ����
        //��ǻ� ������ method
    }

    // if a monster killed, call this method
    public void SubtractRemain()
    {
        Debug.Log("AddKill");
        Kill++;
        RemainKill--;

        if ( (RemainKill == 0) && (GameManager.Enemy.Level < 6) )
        {
            GameManager.Enemy.LevelUp();
        }
    }
}
