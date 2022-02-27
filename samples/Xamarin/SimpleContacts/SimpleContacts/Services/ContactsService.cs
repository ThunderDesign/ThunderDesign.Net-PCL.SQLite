using SimpleContacts.Database.Bridges;
using SimpleContacts.Models;
using System.Threading.Tasks;
using ThunderDesign.Net.ToolBox.Extentions;

namespace SimpleContacts.Services
{
    public static class ContactsService
    {
        #region methods
        public async static Task<ContactsBridge> GetContactsAsync()
        {
            return await Task.Run<ContactsBridge>(() => ContactsBridge.Instance).ConfigureAwait(false);
        }

        public async static Task<ContactsModel> GetContactAsync(ushort Id)
        {
            ContactsModel result = null;

            await Task.Run(() =>
            {
                if (Id == 0)
                {
                    result = new ContactsModel();
                }
                else if (ContactsBridge.Instance.TryGetValue(Id, out var liveContactsModel))
                {
                    result = new ContactsModel();
                    result.Mirror(liveContactsModel);
                }
            }).ConfigureAwait(false);

            return result;
        }

        public async static Task<bool> SaveContactAsync(ContactsModel contactsModel)
        {
            bool result = false;

            await Task.Run(() =>
            {
                if (contactsModel.Id == 0)
                {
                    ContactsBridge.Instance.Add(contactsModel);
                    result = true;
                }
                else
                {
                    if (ContactsBridge.Instance.TryGetValue(contactsModel.Id, out var liveContactModel))
                    {
                        liveContactModel.Mirror(contactsModel);
                        result = true;
                    }
                }
            }).ConfigureAwait(false);

            return result;
        }

        public async static Task<bool> DeleteContactAsync(ushort Id)
        {
            bool result = false;

            await Task.Run(() =>
            {
                if (ContactsBridge.Instance.ContainsKey(Id))
                    result = ContactsBridge.Instance.Remove(Id);
            }).ConfigureAwait(false);

            return result;
        }
        #endregion
    }
}
