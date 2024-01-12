using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Teste___V.Models;

namespace Teste___V.Controllers {
    internal class ResponseHelper {
        public ResponseHelper() {
        }

        internal IActionResult CreateResponse(HttpResponse response, object value) {
            throw new NotImplementedException();
        }

        internal IActionResult CreateResponse(ClienteM clienteM) {
            throw new NotImplementedException();
        }

        internal IActionResult CreateResponse(object value) {
            throw new NotImplementedException();
        }
    }
}