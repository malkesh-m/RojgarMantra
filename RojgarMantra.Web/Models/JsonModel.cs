using Newtonsoft.Json;
using RojgarMantra.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace RojgarMantra
{
    public enum JsonType
    {
        Error = 0,
        Success = 1,
        Info = 2,
        Warning = 3,
        Question = 4
    }

    public class JsonModel
    {
        public JsonModel()
        {
        }

        public JsonModel(JsonType jsonType, string message, string title = null, object result = null)
        {
            JsonType = jsonType;
            Message = message;
            Title = title;
            Result = result;
        }

        public string AlertType => JsonType.ToString();

        /*[ScriptIgnore]*/
        public JsonType JsonType { get; set; }

        public string Message { get; set; }
        public object Result { get; set; }
        public string Title { get; set; }

        public static JsonModel DeleteSuccess(string name)
        {
            return new JsonModel(JsonType.Success, "Delete", name + " " + GlobalConstant.Deleted);
        }
        public static JsonModel DeleteFailed(string name)
        {
            return new JsonModel(JsonType.Error, "Delete", name + " " + GlobalConstant.DeleteFailed);
        }
        public static JsonModel UpdateSuccess(string name)
        {
            return new JsonModel(JsonType.Success, "Update", name + " " + GlobalConstant.Updated);
        }
        public static JsonModel UpdateFailed(string name)
        {
            return new JsonModel(JsonType.Error, "Update", name + " " + GlobalConstant.UpdateFailed);
        }
        public static JsonModel CreateSuccess(string name)
        {
            return new JsonModel(JsonType.Success, "Create", name + " " + GlobalConstant.Created);
        }
        public static JsonModel CreateFailed(string name)
        {
            return new JsonModel(JsonType.Error, "Create", name + " " + GlobalConstant.CreateFailed);
        }

        public static JsonModel ModelStateError(System.Web.Mvc.ModelStateDictionary modelState)
        {
            string errors = JsonConvert.SerializeObject(modelState.Values
                .SelectMany(state => state.Errors)
                .Select(error => error.ErrorMessage));
            return new JsonModel(JsonType.Error, errors);
        }
    }
}
