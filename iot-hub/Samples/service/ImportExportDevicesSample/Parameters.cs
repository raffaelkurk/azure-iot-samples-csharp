﻿using System;
using CommandLine;

namespace Microsoft.Azure.Devices.Samples
{
    /// <summary>
    /// Configurable parameters for the sample.
    /// </summary>
    internal class Parameters
    {
        [Option(
            'i',
            "SourceIoTHubConnectionString",
            Required = true,
            HelpText = "The service connection string with permissions to manage devices for the source IoT hub to copy devices. Log into https://azure.portal.com, go to Resources, open the IoT hub, open Shared Access Policies, open iothubowner, and copy a connection string.")]
        public string SourceIotHubConnectionString { get; set; } = Environment.GetEnvironmentVariable("SOURCE_IOTHUB_CONN_STRING_CSHARP");

        [Option(
            'd',
            "DestIoTHubConnectionString",
            Required = true,
            HelpText = "The service connection string with permissions to manage devices for the destination IoT hub to migrate devices. Log into https://azure.portal.com, go to Resources, open the IoT hub, open Shared Access Policies, open iothubowner, and copy a connection string.")]
        public string DestIotHubConnectionString { get; set; } = Environment.GetEnvironmentVariable("DEST_IOTHUB_CONN_STRING_CSHARP");

        [Option(
            's',
            "StorageConnectionString",
            Required = true,
            HelpText = "The storage account connection string to use with the IoT hub for migrating device data. Log into https://azure.portal.com, go to Resources, open the storage account, open Access Keys, and copy a connection string.")]
        public string StorageConnectionString { get; set; } = Environment.GetEnvironmentVariable("STORAGE_CONN_STRING_CSHARP");

        [Option(
            "AddDevices",
            Default = 0,
            HelpText = "Generates the specified number of new devices (and configurations, if specified) and add to the source IoT hub, for migration to the destination IoT hub.")]
        public int AddDevices { get; set; }

        [Option(
            "CopyDevices",
            Default = true,
            HelpText = "Copies devices (and configurations, if specified) from the source to the destionation IoT hub.")]
        public bool CopyDevices { get; set; }

        [Option(
            "DeleteSourceDevices",
            Default = false,
            HelpText = "Deletes generated devices (and configurations, if specified) in the source IoT hub, after migration and this sample is finished.")]
        public bool DeleteSourceDevices { get; set; }

        [Option(
            "DeleteDestDevices",
            Default = false,
            HelpText = "Delete the devices (and configurations, if specified) that were migrated in the destionation IoT hub, after migration and this sample is finished.")]
        public bool DeleteDestDevices { get; set; }

        [Option(
            "ContainerName",
            Default = "iothub",
            HelpText = "The storage account container name for importing and exporting IoT hub devices (and configurations, if specified).")]
        public string ContainerName { get; set; }

        [Option(
            "BlobNamePrefix",
            Default = "ImportExportSample-",
            HelpText = "The prefix of the blob names to use in the storage account container for importing and exporting devices. That prefix will be used to create unique names for each step in the sample.")]
        public string BlobNamePrefix { get; set; }

        [Option(
            "IncludeConfigurations",
            Default = false,
            HelpText = "Include configurations in the generation, import, export, and clean-up. See https://docs.microsoft.com/azure/iot-hub/iot-hub-automatic-device-management.")]
        public bool IncludeConfigurations { get; set; }

        /// <summary>
        /// Loads up from environment variables for types that require parsing.
        /// </summary>
        public Parameters()
        {
            string addDevicesEnv = Environment.GetEnvironmentVariable("NUM_TO_ADD");
            if (!string.IsNullOrWhiteSpace(addDevicesEnv)
                && int.TryParse(addDevicesEnv, out int addDevices))
            {
                AddDevices = addDevices;
            }

            string copyDevicesEnv = Environment.GetEnvironmentVariable("COPY_DEVICES");
            if (!string.IsNullOrWhiteSpace(copyDevicesEnv)
                && bool.TryParse(copyDevicesEnv, out bool copyDevices))
            {
                CopyDevices = copyDevices;
            }

            string deleteFromDevicesEnv = Environment.GetEnvironmentVariable("DELETE_SOURCE_DEVICES");
            if (!string.IsNullOrWhiteSpace(deleteFromDevicesEnv)
                && bool.TryParse(deleteFromDevicesEnv, out bool deleteFromDevices))
            {
                DeleteSourceDevices = deleteFromDevices;
            }

            string deleteToDevicesEnv = Environment.GetEnvironmentVariable("DELETE_DEST_DEVICES");
            if (!string.IsNullOrWhiteSpace(deleteToDevicesEnv)
                && bool.TryParse(deleteToDevicesEnv, out bool deleteToDevices))
            {
                DeleteSourceDevices = deleteToDevices;
            }
        }
    }
}
