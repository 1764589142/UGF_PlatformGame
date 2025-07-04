using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerGame
{
    public class MenuForm : UGuiForm
    {
        /// <summary>
        /// 菜单流程
        /// </summary>
        private ProcedureMenu m_ProcedureMenu = null;

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            m_ProcedureMenu = (ProcedureMenu)userData;
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            m_ProcedureMenu = null;
            base.OnClose(isShutdown, userData);
        }

        public void OnStartButtonClick()
        {
            m_ProcedureMenu.IsStartGame = true;
        }

        public void OnSettingButtonClick()
        {
            GameEntry.UI.OpenUIForm(UIFormId.SettingForm);
        }
        public void OnExitButtonClick()
        {
            //TODO: 游戏结束
        }
    }
}

