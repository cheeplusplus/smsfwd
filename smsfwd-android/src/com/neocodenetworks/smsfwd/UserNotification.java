// SMSFWD by Andrew Koester <andrew@neocodenetworks.com>

package com.neocodenetworks.smsfwd;

import android.app.*;
import android.content.*;

/**
 * Notify the user of any activity.
 * @author Andrew
 */
public final class UserNotification {
	public static final int ERROR_ID = 1;
	
	/**
	 * Notify the user of an error.
	 * @param context - Activity context
	 * @param message - Error message to display
	 */
	public static void NotifyError(Context context, String message)	{
		NotifyError(context, message, false);
	}
	
	/**
	 * Notify the user of an error.
	 * @param context - Activity context
	 * @param message - Error message to display
	 * @param showConfig - Show configuration window on completion
	 */
	public static void NotifyError(Context context, String message, Boolean showConfig) {
		Notification notification = new Notification(R.drawable.failed, "", System.currentTimeMillis());
		PendingIntent contentIntent;

		Intent alertIntent = new Intent(context, AlertActivity.class);
		alertIntent.setAction(AlertActivity.ALERT);
		alertIntent.putExtra(AlertActivity.ALERT_EXTRA_TITLE, "smsfwd error");
		alertIntent.putExtra(AlertActivity.ALERT_EXTRA_MESSAGE, message);
		alertIntent.putExtra(AlertActivity.ALERT_EXTRA_SHOWCONF, showConfig);
		contentIntent = PendingIntent.getActivity(context, 0, alertIntent, PendingIntent.FLAG_UPDATE_CURRENT);
		
		notification.setLatestEventInfo(context, "smsfwd error", "Click here for detail", contentIntent);
		notification.flags = Notification.FLAG_AUTO_CANCEL;
		
		NotificationManager notificationManager = (NotificationManager)context.getSystemService(Context.NOTIFICATION_SERVICE);
		notificationManager.notify(ERROR_ID, notification);
	}
}
