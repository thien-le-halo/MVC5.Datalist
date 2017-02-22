﻿using Datalist.Tests.Objects;
using NSubstitute;
using System;
using System.Collections;
using System.Web.Mvc;
using Xunit;

namespace Datalist.Tests.Unit
{
    public class DatalistExtensionsTests
    {
        private TestDatalist<TestModel> datalist;
        private HtmlHelper<TestModel> html;

        public DatalistExtensionsTests()
        {
            html = MockHtmlHelper();
            datalist = new TestDatalist<TestModel>();

            datalist.Filter.Page = 2;
            datalist.Filter.Rows = 11;
            datalist.Title = "Dialog title";
            datalist.Filter.Search = "Test";
            datalist.AdditionalFilters.Clear();
            datalist.Filter.SortColumn = "First";
            datalist.AdditionalFilters.Add("Add1");
            datalist.AdditionalFilters.Add("Add2");
            datalist.Url = "http://localhost/Datalist";
            datalist.Filter.SortOrder = DatalistSortOrder.Desc;
        }

        #region AutoComplete<TModel>(this IHtmlHelper<TModel> html, String name, MvcDatalist model, Object value = null, Object htmlAttributes = null)

        [Fact]
        public void AutoComplete_FromModel()
        {
            String actual = html.AutoComplete("Test", datalist, "Value", new { @class = "classes", attribute = "attr" }).ToString();
            String expected =
                "<input attribute=\"attr\" class=\"classes form-control datalist-input\" " +
                    "data-datalist-filters=\"Add1,Add2\" data-datalist-for=\"Test\" data-datalist-page=\"2\" " +
                    "data-datalist-rows=\"11\" data-datalist-search=\"Test\" data-datalist-sort-column=\"First\" " +
                    "data-datalist-sort-order=\"Desc\" data-datalist-title=\"Dialog title\" data-datalist-url=\"http://localhost/Datalist\" " +
                    "id=\"TestDatalist\" name=\"TestDatalist\" type=\"text\" value=\"\" />" +
                "<input class=\"datalist-hidden-input\" id=\"Test\" name=\"Test\" type=\"hidden\" value=\"Value\" />";

            Assert.Equal(expected, actual);
        }

        #endregion

        #region AutoCompleteFor<TModel, TProperty>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, Object htmlAttributes = null)

        [Fact]
        public void AutoCompleteFor_NoModel_Throws()
        {
            Exception actual = Assert.Throws<DatalistException>(() => html.AutoCompleteFor(model => model.Id));

            Assert.Equal("'Id' property does not have a 'DatalistAttribute' specified.", actual.Message);
        }

        [Fact]
        public void AutoCompleteFor_Expression()
        {
            String actual = html.AutoCompleteFor(model => model.ParentId, new { @class = "classes", attribute = "attr" }).ToString();
            String expected =
                "<input attribute=\"attr\" class=\"classes form-control datalist-input\" " +
                    "data-datalist-filters=\"Test1,Test2\" data-datalist-for=\"ParentId\" data-datalist-page=\"3\" " +
                    "data-datalist-rows=\"7\" data-datalist-search=\"Term\" data-datalist-sort-column=\"Id\" " +
                    "data-datalist-sort-order=\"Asc\" data-datalist-title=\"Test title\" data-datalist-url=\"http://localhost/Test\" " +
                    "id=\"ParentIdDatalist\" name=\"ParentIdDatalist\" type=\"text\" value=\"\" />" +
                "<input class=\"datalist-hidden-input\" id=\"ParentId\" name=\"ParentId\" type=\"hidden\" value=\"Model&#39;s parent ID\" />";

            Assert.Equal(expected, actual);
        }

        #endregion

        #region AutoCompleteFor<TModel, TProperty>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, MvcDatalist model, Object htmlAttributes = null)

        [Fact]
        public void AutoCompleteFor_FromModelExpression()
        {
            String actual = html.AutoCompleteFor(model => model.ParentId, datalist, new { @class = "classes", attribute = "attr" }).ToString();
            String expected =
                "<input attribute=\"attr\" class=\"classes form-control datalist-input\" " +
                    "data-datalist-filters=\"Add1,Add2\" data-datalist-for=\"ParentId\" data-datalist-page=\"2\" " +
                    "data-datalist-rows=\"11\" data-datalist-search=\"Test\" data-datalist-sort-column=\"First\" " +
                    "data-datalist-sort-order=\"Desc\" data-datalist-title=\"Dialog title\" data-datalist-url=\"http://localhost/Datalist\" " +
                    "id=\"ParentIdDatalist\" name=\"ParentIdDatalist\" type=\"text\" value=\"\" />" +
                "<input class=\"datalist-hidden-input\" id=\"ParentId\" name=\"ParentId\" type=\"hidden\" value=\"Model&#39;s parent ID\" />";

            Assert.Equal(expected, actual);
        }

        #endregion

        #region Datalist<TModel>(this IHtmlHelper<TModel> html, String name, MvcDatalist model, Object value = null, Object htmlAttributes = null)

        [Fact]
        public void Datalist_FromModel()
        {
            String actual = html.Datalist("Test", datalist, "Value", new { @class = "classes", attribute = "attr" }).ToString();
            String expected =
                "<div class=\"input-group\">" +
                    "<input attribute=\"attr\" class=\"classes form-control datalist-input\" " +
                        "data-datalist-filters=\"Add1,Add2\" data-datalist-for=\"Test\" data-datalist-page=\"2\" " +
                        "data-datalist-rows=\"11\" data-datalist-search=\"Test\" data-datalist-sort-column=\"First\" " +
                        "data-datalist-sort-order=\"Desc\" data-datalist-title=\"Dialog title\" data-datalist-url=\"http://localhost/Datalist\" " +
                        "id=\"TestDatalist\" name=\"TestDatalist\" type=\"text\" value=\"\" />" +
                    "<input class=\"datalist-hidden-input\" id=\"Test\" name=\"Test\" type=\"hidden\" value=\"Value\" />" +
                    "<span class=\"datalist-open-span input-group-addon\">" +
                        "<span class=\"datalist-open-icon glyphicon\"></span>" +
                    "</span>" +
                "</div>";

            Assert.Equal(expected, actual);
        }

        #endregion

        #region DatalistFor<TModel, TProperty>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, Object htmlAttributes = null)

        [Fact]
        public void DatalistFor_NoModel_Throws()
        {
            Exception actual = Assert.Throws<DatalistException>(() => html.DatalistFor(model => model.Id));

            Assert.Equal("'Id' property does not have a 'DatalistAttribute' specified.", actual.Message);
        }

        [Fact]
        public void DatalistFor_Expression()
        {
            String actual = html.DatalistFor(model => model.ParentId, new { @class = "classes", attribute = "attr" }).ToString();
            String expected =
                "<div class=\"input-group\">" +
                    "<input attribute=\"attr\" class=\"classes form-control datalist-input\" " +
                    "data-datalist-filters=\"Test1,Test2\" data-datalist-for=\"ParentId\" data-datalist-page=\"3\" " +
                    "data-datalist-rows=\"7\" data-datalist-search=\"Term\" data-datalist-sort-column=\"Id\" " +
                    "data-datalist-sort-order=\"Asc\" data-datalist-title=\"Test title\" data-datalist-url=\"http://localhost/Test\" " +
                    "id=\"ParentIdDatalist\" name=\"ParentIdDatalist\" type=\"text\" value=\"\" />" +
                    "<input class=\"datalist-hidden-input\" id=\"ParentId\" name=\"ParentId\" type=\"hidden\" value=\"Model&#39;s parent ID\" />" +
                    "<span class=\"datalist-open-span input-group-addon\">" +
                        "<span class=\"datalist-open-icon glyphicon\"></span>" +
                    "</span>" +
                "</div>";

            Assert.Equal(expected, actual);
        }

        #endregion

        #region DatalistFor<TModel, TProperty>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, MvcDatalist model, Object htmlAttributes = null)

        [Fact]
        public void DatalistFor_ExpressionWithModel()
        {
            String actual = html.DatalistFor(model => model.ParentId, datalist, new { @class = "classes", attribute = "attr" }).ToString();
            String expected =
                "<div class=\"input-group\">" +
                    "<input attribute=\"attr\" class=\"classes form-control datalist-input\" " +
                    "data-datalist-filters=\"Add1,Add2\" data-datalist-for=\"ParentId\" data-datalist-page=\"2\" " +
                    "data-datalist-rows=\"11\" data-datalist-search=\"Test\" data-datalist-sort-column=\"First\" " +
                    "data-datalist-sort-order=\"Desc\" data-datalist-title=\"Dialog title\" data-datalist-url=\"http://localhost/Datalist\" " +
                    "id=\"ParentIdDatalist\" name=\"ParentIdDatalist\" type=\"text\" value=\"\" />" +
                    "<input class=\"datalist-hidden-input\" id=\"ParentId\" name=\"ParentId\" type=\"hidden\" value=\"Model&#39;s parent ID\" />" +
                    "<span class=\"datalist-open-span input-group-addon\">" +
                        "<span class=\"datalist-open-icon glyphicon\"></span>" +
                    "</span>" +
                "</div>";

            Assert.Equal(expected, actual);
        }

        #endregion

        #region Test helpers

        private HtmlHelper<TestModel> MockHtmlHelper()
        {
            ViewDataDictionary<TestModel> viewData = new ViewDataDictionary<TestModel>(new TestModel());
            IViewDataContainer container = Substitute.For<IViewDataContainer>();
            viewData.Model.ParentId = "Model's parent ID";
            container.ViewData = viewData;

            ViewContext viewContext = Substitute.For<ViewContext>();
            viewContext.HttpContext.Items.Returns(new Hashtable());
            viewContext.ViewData = viewData;

            return new HtmlHelper<TestModel>(viewContext, container);
        }

        #endregion
    }
}
