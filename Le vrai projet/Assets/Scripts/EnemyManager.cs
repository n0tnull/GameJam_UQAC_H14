﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18052
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

public class EnemyManager
{
	private static EnemyManager instance;
	
	private EnemyManager() {}
	
	public static EnemyManager Instance
	{
		get 
		{
			if (instance == null)
			{
				enemies = new List<Enemy>();
				instance = new EnemyManager();
			}
			return instance;
		}
	}

	//---------------------------------------------------------------------

	private static List<Enemy> enemies;

	public void AddEnemy(Enemy enemy)
	{
		enemies.Add (enemy);
	}

	public void RemoveEnemy(Enemy enemy)
	{
		enemies.Remove(enemy);
	}

	public void Restart()
	{
		foreach(Enemy enemy in enemies)
		{
			enemy.Restart();
		}
	}

	public void Clear()
	{
		enemies.Clear();
	}
}
