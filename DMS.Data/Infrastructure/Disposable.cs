﻿using System;

namespace DMS.Data.Infrastructure
{
    public class Disposable : IDisposable
    {
        public bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);//dung de thu hoi lai bo nho
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        //Override this to dispose customer objects
        protected virtual void DisposeCore()
        { }
    }
}