using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Zebu.DB
{
    public class NameDetailDB : MonoBehaviour
    {
        [SerializeField] private List<string> _nameDistrDetail;

        public List<string> NameDistrDetail => _nameDistrDetail;
    }
}