using System.Collections.Generic;
using UnityEngine;

namespace Zebu.DB
{
    public class KeyTokenDB : MonoBehaviour
    {
        [SerializeField] private List<string> _keyDistrTok;

        public List<string> KeyDistrTok => _keyDistrTok;
    }
}