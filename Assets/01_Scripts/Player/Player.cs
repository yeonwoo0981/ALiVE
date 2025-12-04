using System;
using _01_Scripts.Agent;
using _01_Scripts.System;
using UnityEngine;

namespace _01_Scripts.Player
{
   public class Player : MonoBehaviour
   {
      [field:SerializeField] public MoveCompo MoveCompo { get; private set; }
      [field:SerializeField] public DashCompo DashCompo { get; private set; }
      [field:SerializeField] public HealthSystem HealthCompo { get; private set; }
      
      
   }
}
