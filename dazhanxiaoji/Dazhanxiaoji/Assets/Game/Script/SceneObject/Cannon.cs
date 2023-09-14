﻿using com;
using System.Collections;
using UnityEngine;

namespace Assets.Game.Script.SceneObject
{

    public class Cannon : MonoBehaviour
    {
        public GameObject bulletPrefab;

        public float interval;

        public Transform muzzle;

        public bool activated;//minion died or not
        public float distanceXFromPlayer = 30;

        private float _nextOpenFireTime;

        private void Start()
        {
            _nextOpenFireTime = Time.time + interval;
        }

        private void Update()
        {
            if (!activated)
                return;

            var player = PlayerBehaviour.instance;
            if (player == null)
                return;
            var dir = player.transform.position - transform.position;
            dir.y = 0;
            dir.z = 0;
            var dist = dir.magnitude;
            if (dist > distanceXFromPlayer)
                return;

            if (Time.time > _nextOpenFireTime)
                Fire();
        }

        void Fire()
        {
            SoundSystem.instance.Play("FireCannon");
            Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);
            _nextOpenFireTime = Time.time + interval;
        }
    }
}