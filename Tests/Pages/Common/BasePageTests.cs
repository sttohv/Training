using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Aids;
using Training.Core;

namespace Training.Tests.Pages.Common
{
    public abstract class BasePageTests<TData, TView>
       where TData : IBaseEntity, new()
       where TView : IEntityData
    {
        protected dynamic pageModel;
        protected TestRepo<TData> mockRepo;
        private object onGetDeleteAsync(string id, object result = null)
        {
            mockRepo.Result = result;
            return pageModel?.OnGetDeleteAsync(id)?.GetAwaiter().GetResult();
        }
        private object onGetDetailsAsync(string id, object result = null)
        {
            mockRepo.Result = result;
            return pageModel?.OnGetDetailsAsync(id)?.GetAwaiter().GetResult();
        }
        private object onGetEditAsync(string id, object result = null)
        {
            mockRepo.Result = result;
            return pageModel?.OnGetEditAsync(id)?.GetAwaiter().GetResult();
        }

        private object onPostCreateAsync(dynamic newItem = null)
        {
            pageModel.Item = newItem;
            return pageModel.OnPostCreateAsync().GetAwaiter().GetResult();
        }
        private object onPostEditAsync(int id, object newItem = null,
        object oldItem = null)
        {
            pageModel.Item = newItem;
            mockRepo.Result = oldItem;
            return pageModel.OnPostEditAsync(id).GetAwaiter().GetResult();
        }
        private object onPostDeleteAsync(int id, object oldItem = null)
        {
            mockRepo.Result = oldItem;
            return pageModel.OnPostDeleteAsync(id).GetAwaiter().GetResult();
        }
        [TestMethod]
        public void OnGetDeleteAsyncTestItemNotFound()
            => Assert.IsInstanceOfType(onGetDeleteAsync(GetRandom.String()), typeof(NotFoundResult));
        [TestMethod]
        public void OnGetDeleteAsyncTestIsCallingGet()
        {
            var i = GetRandom.String();
            onGetDeleteAsync(i);
            Assert.AreEqual($"Get {i}", mockRepo.Actions[0]);
        }
        [TestMethod]
        public void OnGetDeleteAsyncTestPageResult()
            => Assert.IsInstanceOfType(
                onGetDeleteAsync(GetRandom.String(), new TData()), typeof(PageResult));

        [TestMethod]
        public void OnGetDetailsAsyncTestItemNotFound()
            => Assert.IsInstanceOfType(onGetDetailsAsync(GetRandom.String()), typeof(NotFoundResult));
        [TestMethod]
        public void OnGetDetailsAsyncTestIsCallingGet()
        {
            var i = GetRandom.String();
            onGetDetailsAsync(i);
            Assert.AreEqual($"Get {i}", mockRepo.Actions[0]);
        }
        [TestMethod]
        public void OnGetDetailsAsyncTestPageResult()
            => Assert.IsInstanceOfType(
                onGetDetailsAsync(GetRandom.String(), new TData()), typeof(PageResult));

        [TestMethod]
        public void OnGetEditAsyncTestItemNotFound()
            => Assert.IsInstanceOfType(onGetEditAsync(GetRandom.String()), typeof(NotFoundResult));
        [TestMethod]
        public void OnGetEditAsyncTestIsCallingGet()
        {
            var i = GetRandom.String();
            onGetEditAsync(i);
            Assert.AreEqual($"Get {i}", mockRepo.Actions[0]);
        }
        [TestMethod]
        public void OnGetEditAsyncTestPageResult()
            => Assert.IsInstanceOfType(
                onGetEditAsync(GetRandom.String(), new TData()), typeof(PageResult));

        [TestMethod]
        public void OnGetCreateTestPageResult()
            => Assert.IsInstanceOfType(pageModel.OnGetCreate(), typeof(PageResult));

        //[TestMethod] public void OnPostCreateTestCorrectModelState()
        //    => Assert.IsInstanceOfType(onPostCreateAsync(), typeof(RedirectResult));
        //[TestMethod] public void OnPostCreateTestIncorrectModelState()
        //    => Assert.IsInstanceOfType(onPostCreateAsync(null), typeof(PageResult));
        //[TestMethod] public void OnPostCreateTestShouldIgnoreIdAndRowVersion()
        //    => Assert.IsInstanceOfType(onPostCreateAsync(), typeof(RedirectResult));

        [TestMethod]
        public void OnPostCreateTestIsCallingAdd()
        {
            var o = CreateNew.Instance<TView>();
            onPostCreateAsync(o);
            Assert.AreEqual($"AddAsync {o.Id}", mockRepo.Actions[0]);
        }
    }
}
