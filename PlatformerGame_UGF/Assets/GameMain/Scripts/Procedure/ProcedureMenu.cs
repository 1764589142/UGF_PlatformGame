using GameFramework.Event;
using GameFramework.Fsm;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace PlatformerGame{
    public class ProcedureMenu : ProcedureBase
    {
        public override bool UseNativeDialog => false;

        public bool IsStartGame { get; set; }

        /// <summary>
        /// �˵��ű�
        /// </summary>
        private MenuForm m_MenuForm = null;

        protected override void OnEnter(IFsm<GameFramework.Procedure.IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Info("�ɹ�����Menu����");

            
            IsStartGame = false;

            //����UI�򿪳ɹ��¼�
            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            //��Menu UI����
            GameEntry.UI.OpenUIForm(UIFormId.MenuForm, this);
        }

        

        protected override void OnUpdate(IFsm<GameFramework.Procedure.IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (IsStartGame)
            {
                Log.Info("��ʼ��Ϸ");
            }
        }

        protected override void OnLeave(IFsm<GameFramework.Procedure.IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            if(m_MenuForm != null)
            {
                m_MenuForm.Close(isShutdown);
                m_MenuForm = null;
            }

            //ȡ������UI�򿪳ɹ��¼�
            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
        }


        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            Log.Info("UI�򿪳ɹ�");
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            m_MenuForm = (MenuForm)ne.UIForm.Logic;
        }
    }
}

