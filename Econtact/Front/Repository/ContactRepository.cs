﻿using Econtact.Front.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econtact.Front.Repository
{
    class ContactRepository
    {
        List<Contact> contacts = new List<Contact>();

        public List<Contact> List()
        {
            return contacts;
        }

        public Contact Insert(Contact contact)
        {
            contacts.Add(contact);
            return contacts.Find(c => c.Id == contact.Id);
        }

        public Contact Update(Contact contact)
        {
            contacts.ForEach(c =>
            {
                if (c.Id == contact.Id)
                {
                    c.FirstName = contact.FirstName;
                    c.LastName = contact.LastName;
                    c.Address = contact.Address;
                    c.ContactNo = contact.ContactNo;
                    c.Gender = contact.Gender;
                }
            });
            return contacts.Find(c => c.Id == contact.Id);
        }

        public int Delete(int id)
        {
            contacts.RemoveAt(contacts.FindIndex(c => c.Id == id));
            return 1;
        }

        public List<Contact> List(string text)
        {
            return contacts.FindAll((c) => (c.FirstName.ToUpper().Contains(text.ToUpper())
                || c.LastName.ToUpper().Contains(text.ToUpper())
                || c.Address.ToUpper().Contains(text.ToUpper())
                || c.ContactNo.ToUpper().Contains(text.ToUpper())
                || c.Gender.ToUpper().Contains(text.ToUpper()))
            );
        }
    }
}
