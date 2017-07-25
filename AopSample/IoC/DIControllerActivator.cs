﻿using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace AopSample.IoC
{
    public class DIControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType) {
            var controller = (IHttpController)Container.Resolve(controllerType);
            request.RegisterForDispose(new Release(() => Container.Release(controller)));
            return controller;
        }

        private class Release : IDisposable
        {
            private readonly Action release;

            public Release(Action release) {
                this.release = release;
            }

            public void Dispose() {
                release();
            }
        }
    }
}