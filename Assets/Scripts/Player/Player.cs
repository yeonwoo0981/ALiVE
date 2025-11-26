using System;
using Agent;
using UnityEngine;

namespace Player
{
   public class Player : MonoBehaviour
   {
      [field:SerializeField] public MoveCompo MoveCompo { get; private set; }
      [field:SerializeField] public DashCompo DashCompo { get; private set; }
      [field:SerializeField] public HealthSystem HealthCompo { get; private set; }
      
      
   }
}
