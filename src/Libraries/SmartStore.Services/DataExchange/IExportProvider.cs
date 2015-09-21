﻿using System;
using SmartStore.Core.Domain.DataExchange;
using SmartStore.Core.Plugins;

namespace SmartStore.Services.DataExchange
{
	public partial interface IExportProvider : IProvider, IUserEditable
	{
		/// <summary>
		/// Th exported entity type
		/// </summary>
		ExportEntityType EntityType { get; }

		/// <summary>
		/// File extension of the export files (without dot). Return <c>null</c> for a non file based, on-the-fly export.
		/// </summary>
		string FileExtension { get; }

		/// <summary>
		/// Get configuration information
		/// </summary>
		/// <param name="partialViewName">The partial view name for the configuration</param>
		/// <param name="modelType">Type of the view model</param>
		/// <param name="initialize">Callback to initialize the view model. Can be <c>null</c>.</param>
		/// <returns>Whether configuration is required</returns>
		bool RequiresConfiguration(out string partialViewName, out Type modelType, out Action<object> initialize);

		/// <summary>
		/// Export data to a file
		/// </summary>
		/// <param name="context">Export execution context</param>
		void Execute(IExportExecuteContext context);

		/// <summary>
		/// Called once per store when export execution ended
		/// </summary>
		/// <param name="context">Export execution context</param>
		void ExecuteEnded(IExportExecuteContext context);
	}
}