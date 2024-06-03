using System.Diagnostics;
using CatPhotoApi.MockServer;

new MockServerReplacement().InitServerReplacement();

var pt = typeof(CatPhotoApi.Program);

pt.GetMethod("Main").Invoke(null, new object[1]{new string[0]});
