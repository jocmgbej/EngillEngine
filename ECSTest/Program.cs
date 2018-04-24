using System;
using System.Diagnostics;
using EngillEngine.EntityComponentSystem.EntityManagement;
using System.Net;
using System.Runtime.CompilerServices;
using EngillEngine.EntityComponentSystem.ComponentManagement;

namespace ECSTest
{
	class MainClass
	{
		private static uint numOfEntities = 5000;
		private static Stopwatch sw;

		public static void Main(string[] args)
		{
			sw = new Stopwatch();
			EntityCreationTest();
			EntityRecycleTest();
		}

		private static void EntityCreationTest()
		{
			EntityManager entityManager;
			entityManager = new EntityManager(numOfEntities);

			sw.Restart();
			for (int i = 0; i < numOfEntities; i++)
			{
				EntityHandle entityHandle = entityManager.CreateEntity();
				entityHandle.Dispose();
			}
			sw.Stop();

			Console.WriteLine("EntityCreationTest");
			Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms\n");
		}

		private static void EntityRecycleTest()
		{
			EntityManager entityManager;
			entityManager = new EntityManager(numOfEntities);

			for (int i = 0; i < numOfEntities; i++)
			{
				EntityHandle entityHandle = entityManager.CreateEntity();
				entityHandle.Dispose();
			}

			for (int i = 0; i < numOfEntities; i++)
			{
				entityManager.RemoveEntity((uint)i);
			}

			sw.Restart();
			for (int i = 0; i < numOfEntities; i++)
			{
				EntityHandle entityHandle = entityManager.CreateEntity();
				entityHandle.Dispose();
			}
			sw.Stop();

			Console.WriteLine("EntityRecreationTest");
			Console.WriteLine(sw.ElapsedMilliseconds.ToString() + "ms\n");
		}

		private class testComponent : IComponent
		{
			public int x, y, z;

			public testComponent(int x, int y, int z)
			{
				this.x = x;
				this.y = y;
				this.z = z;
			}

			public void Reset()
			{
				x = 0;
				y = 0;
				z = 0;
			}
		}

		private static void EntityComponentCreation()
		{            
			EntityManager entityManager;
            entityManager = new EntityManager(numOfEntities);

			for (int i = 0; i < numOfEntities; i++)
            {
                EntityHandle entityHandle = entityManager.CreateEntity();
                entityHandle.Dispose();
            }

			for (int i = 0; i < numOfEntities; i++)
            {
				entityManager.RemoveEntity((uint)i);
            }

			sw.Restart();
            for (int i = 0; i < numOfEntities; i++)
            {
                EntityHandle entityHandle = entityManager.CreateEntity();
                entityHandle.Dispose();
            }
            sw.Stop();
		}
    }
}
